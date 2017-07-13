using AntShares.SmartContract.Framework;
using AntShares.SmartContract.Framework.Services.AntShares;
using System;
using System.Numerics;

namespace ERC20Demo
{
    public class Contract1 : FunctionCode
    {

        public static string name = "lllwvlvwlll Beer Token";
        public static string symbol = "BEER";
        public static int supply = 100;


        public static object Main( string operation , params object[] args )
        {
            switch ( operation )
            {
                case "TotalSupply":
                    return TotalSupply();

                case "BalanceOf":
                    return BalanceOf( (byte[])args[0] );

                case "Transfer":
                    return Transfer( (byte[])args[0] , (byte[])args[1] ,  (byte[])args[2] , (int)args[3] );

                case "TransferFrom":
                    return TransferFrom( (byte[])args[0] , (byte[])args[1] , (byte[])args[2] , (byte[])args[3] , (int)args[4] );

                case "Approve":
                    return Approve( (byte[])args[0] , (byte[])args[1] , (byte[])args[2] , (int)args[3] );

                case "Allowance":
                    return Allowance( (byte[])args[0] , (byte[])args[1] , (byte[])args[2] );

                default:
                    return false;
            }

        }


        ///  <summary>
        ///  Calculates the total circulating supply of tokens.
        ///  Returns: the total supply of tokens in circulation.
        ///  
        ///  </summary>
        private static int TotalSupply()
        {
            return supply;
        }


        ///  <summary>
        ///    Identifies the balance of a user 
        ///    Args:
        ///      owner: The account address to look up.
        ///    Returns:
        ///      int: The account holdings of the input address.
        ///  </summary>        
        private static int BalanceOf( byte[] owner )
        {
            byte[] balance = Storage.Get( Storage.CurrentContext , owner );

            if ( BitConverter.IsLittleEndian )
                Array.Reverse( balance );

            return BitConverter.ToInt32( balance , 0 );
        }


        ///  <summary>
        ///    Transfers a balance to an address
        ///    Args:
        ///      from: the address to transfer tokens from.
        ///      sig: the signature of the from user.
        ///      to: The address to transfer tokens to.
        ///      transValue: The amount of tokens to transfer.
        ///    Returns: 
        ///      bool: Transaction Successful?.   
        ///  </summary>
        private static bool Transfer(byte[] from , byte[] sig , byte[] to , int transValue )
        {
            if (!VerifySignature( from , sig ) ) return false;

            int fromValue = BalanceOf( from );
            int toValue = BalanceOf( to );

            if ( ( fromValue >= transValue ) &&
                ( transValue > 0 ) ) {

                byte[] toByteVal = BitConverter.GetBytes(toValue + transValue);
                byte[] fromByteVal = BitConverter.GetBytes(fromValue - transValue);

                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse( toByteVal );
                    Array.Reverse( fromByteVal );
                }

                Storage.Put( Storage.CurrentContext , from , fromByteVal );
                Storage.Put( Storage.CurrentContext , to , toByteVal );

                return true;
                
            };
        
            return false;
        }


        ///  <summary>
        ///    Transfers a balance from one address to another.
        ///    Args:
        ///      del: the delegate account
        ///      sig: the signature of the 
        ///      from: The address to transfer funds from.
        ///      to: The adress to transfer funds to.
        ///      value: The amount of tokens to transfer.
        ///    Returns:
        ///      bool: Transaction Successful?   
        ///  </summary>
        private static bool TransferFrom( byte[] del , byte[] sig, byte[] from , byte[] to , int value)
        {
            if (!VerifySignature(del, sig)) return false;
            return true;
        }


        ///  <summary>
        ///    Allows a user to withdraw multiple times from an account up to a limit.
        ///    Args:
        ///      owner: The account to allow access to.
        ///      sig: the signature of the account owner
        ///      spender: the account that will be allowed access
        ///      value: The amount the spender can withdraw up to.
        ///    Returns:
        ///      bool: Transaction Successful?
        ///  </summary>
        private static bool Approve( byte[] owner , byte[] sig , byte[] spender , int value)
        {
            if (!VerifySignature(owner, sig)) return false;


            return true;
        }


        ///  <summary>
        ///    Returns the amount that a spender is allowed to spend on an owner's account.
        ///    Args:
        ///      owner: The account with an allowance on it.
        ///      sig: the signature of the account owner
        ///      spender: The account that is authorized to spend.
        ///    Returns:
        ///      int: The number of tokens available to the user.
        ///  </summary>
        private static int Allowance( byte[] owner , byte[] sig, byte[] spender)
        {
            int tokens = 0;

            return tokens;
        }
    }
}
