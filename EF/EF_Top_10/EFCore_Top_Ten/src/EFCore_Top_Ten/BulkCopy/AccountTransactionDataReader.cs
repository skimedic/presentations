#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - AccountTransactionDataReader.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using EFCore_Top_Ten.Models;

namespace EFCore_Top_Ten.BulkCopy
{
    public class AccountTransactionDataReader : DbDataReader
    {
        public AccountTransactionDataReader()
        {
        }

        public AccountTransactionDataReader(List<AccountTransaction> records)
        {
            Records = records;
        }

        public List<AccountTransaction> Records { get; set; }

        private int _currentIndex = -1;

        public override int FieldCount
        {
            get { return 6; }
        }

        public override string GetName(int i)
        {
            switch (i)
            {
                case 0:
                    return "Id";
                case 1:
                    return "AccountID";
                case 2:
                    return "Amount";
                case 3:
                    return "IsChanged";
                case 4:
                    return "Timestamp";
                case 5:
                    return "TransactionDate";
                default:
                    return string.Empty;
            }
        }

        public override int GetOrdinal(string name)
        {
            switch (name)
            {
                case "Id":
                    return 0;
                case "AccountID":
                    return 1;
                case "Amount":
                    return 2;
                case "IsChanged":
                    return 3;
                case "Timestamp":
                    return 4;
                case "TransactionDate":
                    return 5;
                default:
                    return -1;
            }
        }

        public override object GetValue(int i)
        {
            switch (i)
            {
                case 0:
                    return Records[_currentIndex].Id;
                case 1:
                    return Records[_currentIndex].AccountID;
                case 2:
                    return Records[_currentIndex].Amount;
                case 3:
                    return Records[_currentIndex].IsChanged;
                case 4:
                    return Records[_currentIndex].Timestamp;
                case 5:
                    return Records[_currentIndex].TransactionDate;
                default:
                    return string.Empty;
            }
        }

        public override bool Read()
        {
            if ((_currentIndex + 1) >= Records.Count) return false;
            _currentIndex++;
            return true;
        }



        public override bool GetBoolean(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override byte GetByte(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override char GetChar(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override string GetDataTypeName(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetDateTime(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override decimal GetDecimal(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override double GetDouble(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override bool NextResult()
        {
            throw new NotImplementedException();
        }

        public override int Depth { get; }
        public override bool IsClosed { get; }
        public override int RecordsAffected { get; }

        public override object this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public override object this[int ordinal]
        {
            get { throw new NotImplementedException(); }
        }

        public override bool HasRows { get; }

        public override bool IsDBNull(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public override string GetString(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetInt64(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetInt32(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override short GetInt16(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override Guid GetGuid(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override float GetFloat(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override Type GetFieldType(int ordinal)
        {
            throw new NotImplementedException();
        }
    }
}