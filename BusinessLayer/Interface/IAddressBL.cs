using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAddressBL
    {
        public AddressModel AddAddress(AddressModel addAddress);
        public Address_Model UpdateAddress(Address_Model addAddress);
        public List<AddressModel> GetUserAddress();
        public List<AddressModel> GetUserAddressById(long userid);
    }
}
