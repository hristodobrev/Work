﻿using System;
using System.ComponentModel.DataAnnotations;

public class Address
{
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string AddressLine1 { get; set; }

    [Required, MaxLength(20)]
    public string AddressLine2 { get; set; }

    [Required, MaxLength(20)]
    public string City { get; set; }

    [RegularExpression(@"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$")]
    public string ZipCode { get; set; }
}

public class Customer
{
    public int Id { get; set; }

    [Required, MaxLength(20)]
    public string FirstName { get; set; }

    [Required, MaxLength(20)]
    public string LastName { get; set; }

    [Required]
    public Address ShippingAddress { get; set; }

    [Required]
    public Address BillingAddress { get; set; }
}

class CustomerAndAddressClasses
{
    static void Main()
    {

    }
}