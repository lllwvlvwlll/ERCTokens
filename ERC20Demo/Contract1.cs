using AntShares.SmartContract.Framework;
using AntShares.SmartContract.Framework.Services.AntShares;
using System;
using System.Numerics;

namespace ERC20Demo
{
    public class Contract1 : FunctionCode
    {

        public static string name = "Beer IOU Token";
        public static string symbol = "BEER";
        public static int decimals = 18;

        public static object Main(string operation, params object[] args)
        {
            switch (operation)
            {
                case "totalSupply":
                    return totalSupply();

                case "balanceOf":
                    return balanceOf( (string)args[0] );

                case "transfer":
                    return transfer( (string)args[0] , (byte[])args[1] );

                case "transferFrom":
                    return transferFrom( (string)args[0] , (string)args[1] , (byte[])args[2] );

                case "approve":
                    return approve( (string)args[0] , (byte[])args[1] );

                case "allowance":
                    return allowance( (string)args[0] , (string)args[1] );

                default:
                    return false;
            }

        }


        ///  <summary>
        ///  Calculates the total circulating supply of tokens.
        ///  Returns: the total supply of tokens in circulation.
        ///  
        ///  </summary>
        private static byte[] totalSupply()
        {
            byte[] supply = new byte[] { };

            return supply;
        }


        ///  <summary>
        ///    Identifies the balance of a user 
        ///    Args:
        ///      owner: The account address to look up.
        ///    Returns:
        ///      byte[]: The account holdings of the input address.
        ///  </summary>        
        private static byte[] balanceOf( string owner )
        {
            return Storage.Get(Storage.CurrentContext, owner);
        }


        ///  <summary>
        ///    Transfers a balance to an address
        ///    Args:
        ///      to: The address to transfer tokens to.
        ///      value: The amount of tokens to transfer.
        ///    Returns: 
        ///      value: The amount to transfer.   
        ///  </summary>
        private static bool transfer( string to , byte[] value )
        {
            return true;
        }


        ///  <summary>
        ///    Transfers a balance from one address to another.
        ///    Args:
        ///      from: The address to transfer funds from.
        ///      to: The adress to transfer funds to.
        ///      value: The amount of tokens to transfer.
        ///    Returns:
        ///      bool: Transaction Successful?   
        ///  </summary>
        private static bool transferFrom( string from , string to , byte[] value)
        {
            return true;
        }


        ///  <summary>
        ///    Allows a user to withdraw multiple times from an account up to a limit.
        ///    Args:
        ///      spender: The account to allow access.
        ///      value: The amount the spender can withdraw up to.
        ///    Returns:
        ///      bool: Transaction Successful?
        ///  </summary>
        private static bool approve( string spender , byte[] value)
        {
            return true;
        }


        ///  <summary>
        ///    Returns the amount that a spender is allowed to spend on an owner's account.
        ///    Args:
        ///      owner: The account with an allowance on it.
        ///      spender: The account that is authorized to spend.
        ///  </summary>
        private static byte[] allowance( string owner , string spender)
        {
            byte[] tokens = new byte[] { };

            return tokens;
        }
    }
}
