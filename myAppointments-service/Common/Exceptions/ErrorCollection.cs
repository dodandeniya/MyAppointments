using System.Collections;
using System.Collections.Generic;

namespace Common.Exceptions
{
    public class ErrorModel
    {
        public ErrorModel(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class ErrorCollection : ICollection<ErrorModel>
    {
        private List<ErrorModel> errors = new List<ErrorModel>();

        public int Count => errors.Count;

        public bool IsReadOnly => false;

        public void Add(ErrorModel item)
        {
            errors.Add(item);
        }

        public void Clear()
        {
            errors = new List<ErrorModel>();
        }

        public bool Contains(ErrorModel item)
        {
            return errors.Contains(item);
        }

        public void CopyTo(ErrorModel[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ErrorModel> GetEnumerator()
        {
            return errors.GetEnumerator();
        }

        public bool Remove(ErrorModel item)
        {
            return errors.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<ErrorModel> GetErrors()
        {
            return errors;
        }
    }
}