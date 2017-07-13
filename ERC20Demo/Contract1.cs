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
        public static int supply = 100;


        public static object Main(string operation, params object[] args)
        {
            switch (operation)
            {
                case "totalSupply":
                    return totalSupply();

                case "balanceOf":
                    return balanceOf( (byte[])args[0] );

                case "transfer":
                    return transfer( (byte[])args[0] , (int)args[1] );

                case "transferFrom":
                    return transferFrom( (byte[])args[0] , (byte[])args[1] , (int)args[2] );

                case "approve":
                    return approve( (byte[])args[0] , (int)args[1] );

                case "allowance":
                    return allowance( (byte[])args[0] , (byte[])args[1] );

                default:
                    return false;
            }

        }


        ///  <summary>
        ///  Calculates the total circulating supply of tokens.
        ///  Returns: the total supply of tokens in circulation.
        ///  
        ///  </summary>
        private static int totalSupply()
        {
            return supply;
        }


        ///  <summary>
        ///    Identifies the balance of a user 
        ///    Args:
        ///      owner: The account address to look up.
        ///    Returns:
        ///      byte[]: The account holdings of the input address.
        ///  </summary>        
        private static byte[] balanceOf( byte[] owner )
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
        private static bool transfer( byte[] to , int value )
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
        private static bool transferFrom( byte[] from , byte[] to , int value)
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
        private static bool approve( byte[] spender , int value)
        {
            return true;
        }


        ///  <summary>
        ///    Returns the amount that a spender is allowed to spend on an owner's account.
        ///    Args:
        ///      owner: The account with an allowance on it.
        ///      spender: The account that is authorized to spend.
        ///  </summary>
        private static byte[] allowance( byte[] owner , byte[] spender)
        {
            byte[] tokens = new byte[] { };

            return tokens;
        }
    }
}
