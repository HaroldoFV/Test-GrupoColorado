using AutoMapper;
using GrupoColorado.Application.Interfaces;
using GrupoColorado.Application.Models;
using GrupoColorado.Application.Shared;
using GrupoColorado.Domain.Entities;
using GrupoColorado.Domain.Interfaces.Repositories;
using GrupoColorado.Domain.Interfaces.UnitOfWork;
using GrupoColorado.Domain.Validations;
using GrupoColorado.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace GrupoColorado.Application.Services;

public class CustomerAppService : ICustomerAppService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerAppService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Result Get(int page, int pageSize)
    {
        var customers = _unitOfWork
            .CustomerRepository
            .Get(page, pageSize);

        var customersModel = _mapper.Map<IList<GetCustomerModel>>(customers);
        var result = new Result(true, "", customersModel);
        return result;
    }

    public Result GetById(long id)
    {
        var customer = _unitOfWork
            .CustomerRepository
            .GetById(id);

        if (customer == null) return new Result(false, "cliente não encontrado");

        var customerModel = _mapper.Map<GetCustomerModel>(customer);
        var result = new Result(true, "", customerModel);
        return result;
    }

    public Result GetByName(int page, int pageSize, string name)
    {
        var customers = _unitOfWork
            .CustomerRepository
            .GetByName(page, pageSize, name);

        if (customers.Count == 0) return new Result(false, "cliente(s) não encontrado(s)");

        var customersModel = _mapper.Map<IList<GetCustomerModel>>(customers);
        var result = new Result(true, "", customersModel);
        return result;
    }

    public Result Add(RegisterCustomerModel model)
    {
        try
        {
            // Criar VOs
            var address = new Address(model.Address.Street, model.Address.Number, model.Address.Neighborhood,
                model.Address.City, model.Address.State, model.Address.Country, model.Address.ZipCode);

            // Criar entidades
            var customer = new Customer(model.Name, address, model.City, model.State);

            // Validação
            CustomerValidator customerValidator = new();
            var validatorResult = customerValidator.Validate(customer);

            if (!validatorResult.IsValid)
            {
                List<string> erros = new List<string>();
                foreach (var failure in validatorResult.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " +
                                      failure.ErrorMessage);
                    erros.Add(failure.ErrorMessage);
                }

                return new Result(false, "", erros);
            }

            _unitOfWork.CustomerRepository.Add(customer);

            address.SetCustomerId(customer.Id);

            _unitOfWork.AddressRepository.Add(address);

            _unitOfWork.Commit();

            var result = new Result(true, "Cliente cadastrado com sucesso.", customer.Id);

            return result;
        }
        catch (Exception ex)
        {
            var result = new Result(false, ex.Message, 0);
            return result;
        }
    }

    public Result Update(long id, UpdateCustomerModel model)
    {
        var customer = _unitOfWork.CustomerRepository.GetById(id);

        if (customer == null) return new Result(false, "cliente não encontrado");

        customer.Update(model.Name, model.City, model.State);
        Address address = new Address();

        if (model.Address != null)
        {
            // Criar os VOs
            address = new Address(model.Address.Street, model.Address.Number, model.Address.Neighborhood,
                model.Address.City, model.Address.State, model.Address.Country, model.Address.ZipCode);

            address.SetCustomerId(customer.Id);
            customer.UpdateAddress(address);
        }


        // Validação
        CustomerValidator customerValidator = new();
        var validatorResult = customerValidator.Validate(customer);

        if (!validatorResult.IsValid)
        {
            List<string> erros = new List<string>();
            foreach (var failure in validatorResult.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " +
                                  failure.ErrorMessage);
                erros.Add(failure.ErrorMessage);
            }

            return new Result(false, "", erros);
        }

        _unitOfWork.AddressRepository.Update(address);

        _unitOfWork.CustomerRepository.Update(customer);

        _unitOfWork.Commit();

        var result = new Result(true, "Dados do cliente atualizado com sucesso.", customer.Id);
        return result;
    }

    public Result Delete(long id)
    {
        try
        {
            var customer = _unitOfWork.CustomerRepository.GetById(id);

            if (customer == null) return new Result(false, "cliente não encontrado");

            _unitOfWork.AddressRepository.Delete(customer.Address);

            _unitOfWork.CustomerRepository.Delete(customer);

            _unitOfWork.Commit();

            var result = new Result(true, "Cliente removido com sucesso.", customer.Id);
            return result;
        }
        catch (Exception ex)
        {
            var result = new Result(false, ex.Message, 0);
            return result;
        }
    }
}