using BusinessLayer.Interface;
using CommonLayer.Model;
using RepostoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class AddressBL : IAddressBL
    {
        IAddressRL iAddressRL;
        public AddressBL(IAddressRL iAddressRL)
        {
            this.iAddressRL = iAddressRL;
        }

        public AddressModel AddAddress(AddressModel addAddress)
        {
            try
            {
                return iAddressRL.AddAddress(addAddress);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Address_Model UpdateAddress(Address_Model addAddress)
        {
            try
            {
                return iAddressRL.UpdateAddress(addAddress);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<AddressModel> GetUserAddress()
        {
            try
            {
                return iAddressRL.GetUserAddress();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<AddressModel> GetUserAddressById(long userid)
        {
            try
            {
                return iAddressRL.GetUserAddress();
            }
            catch (Exception)
            {

                throw;
            }
        }
    } 
}
