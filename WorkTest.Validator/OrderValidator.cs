﻿using WorkTest.Bll.Models;
using WorkTest.Constants.Exceptions;

namespace WorkTest.Validator;

public class OrderValidator : IOrderValidator
{
    public void OrderCreateModelValidator(Order order)
    {
        IsWithoutLinesValidation(ref order);
        QuantityValidation(ref order);
    }
    public void OrderUpdateModelValidator(Order order)
    {
        UnprocessableStatusValidation(ref order);
        IsWithoutLinesValidation(ref order);
        QuantityValidation(ref order);
    }

    private void IsWithoutLinesValidation(ref Order order)
    {
        if (order.Lines.Count == 0)
        {
            throw new OrderWithoutLinesException("Невозможно создать заказ без строк");
        }
    }
    private void QuantityValidation(ref Order order)
    {
        if (order.Lines.Any(product => product.Qty < 1))
        {
            throw new LineWithNegativeOrZeroQuantityException
                ("Количество по строке заказа должно быть положительным");
        }
    }

    private void UnprocessableStatusValidation(ref Order order)
    {
        if ((int)order.Status is > 5 or < 0)
        {
            throw new StatusNotExistException("Попытка добавить не существующий статус");
        }
    }
}