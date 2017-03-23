using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Validator.Core.ModelResult;

namespace Validator.Core.ModelState
{
    public sealed class ModelState : IModelState
    {
        #region Fields

        private readonly IReadOnlyDictionary<string, IValidationResult> _dictEntry;

        #endregion

        #region Properties

        public int Count => _dictEntry.Count;
      
        public bool IsValid => Count == 0;

        public IEnumerable<string> Keys => _dictEntry.Keys;

        public IEnumerable<IValidationResult> Values => _dictEntry.Values;

        #endregion

        #region Indexers

        public IValidationResult this[string propName]
        {
            get
            {
                if (!_dictEntry.ContainsKey(propName))
                    throw new ArgumentException($"The property {propName} does not contain validation errors");

                return _dictEntry[propName];
            }
        }

        #endregion

        #region Constructors

        public ModelState(IEnumerable<IValidationResult> validators)
        {
            _dictEntry = validators.ToDictionary(k => k.Name, v => v);
        }

        #endregion

        #region Methods

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<string, IValidationResult>> GetEnumerator()
        {
            return _dictEntry.GetEnumerator();
        }

        public IEnumerable<string> GetErrors()
        {
            if (Count == 0) return Enumerable.Empty<string>();

            return Values.SelectMany(v => v.Errors.Select(er => er.ErrorMessage)).Distinct().OrderBy(er => er);
        }

        public bool ContainsKey(string key)
        {
            return _dictEntry.ContainsKey(key);
        }

        public bool TryGetValue(string key, out IValidationResult value)
        {
            return _dictEntry.TryGetValue(key, out value);
        }

        #endregion
    }
}
