#region copyright
// // Copyright Information
// // ==============================
// // DAL - AccountTransactionDataReader.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using DAL.Models;

namespace DAL.BulkCopy
{
    public class AccountTransactionDataReader : IDataReader, IStoreDataReader<AccountTransaction>
    {
        public int Depth { get; }
        public bool IsClosed { get; }
        public int RecordsAffected { get; }
        public List<AccountTransaction> Records { get; set; }

        private int _currentIndex = -1;

        public AccountTransactionDataReader(List<AccountTransaction> records)
        {
            Records = records;
        }

        public AccountTransactionDataReader() { }

        public int FieldCount => 6;

        public string GetName(int i)
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
                    return "TransactionDate";
                case 4:
                    return "IsChanged";
                case 5:
                    return "Timestamp";
                default:
                    return string.Empty;
            }
        }

        public int GetOrdinal(string name)
        {
            switch (name)
            {
                case "Id":
                    return 0;
                case "AccountID":
                    return 1;
                case "Amount":
                    return 2;
                case "TransactionDate":
                    return 3;
                case "IsChanged":
                    return 4;
                case "Timestamp":
                    return 5;
                default:
                    return -1;
            }
        }

        public object GetValue(int i)
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
                    return Records[_currentIndex].TransactionDate;
                case 4:
                    return Records[_currentIndex].IsChanged;
                case 5:
                    return Records[_currentIndex].Timestamp;
                default:
                    return string.Empty;
            }
        }


        public bool Read()
        {
            if ((_currentIndex + 1) >= Records.Count) return false;
            _currentIndex++;
            return true;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }


        object IDataRecord.this[int i]
        {
            get { throw new NotImplementedException(); }
        }

        object IDataRecord.this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

    }
}