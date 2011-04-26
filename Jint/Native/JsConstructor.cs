﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native {
    [Serializable]
    public abstract class JsConstructor : JsObjectBase, IFunction {
        /// <summary>
        /// Stores Global object used for creating this function.
        /// This property may be used in the InitProtype method.
        /// </summary>
        public IGlobal Global { get; set; }

        /// <summary>
        /// Constructs JsContructor, setting [[Prototype]] property to global.FunctionClass.PrototypeProperty
        /// </summary>
        /// <param name="global">Global</param>
        public JsConstructor(IGlobal global)
            : base(global) {
            Global = global;
        }

        /// <summary>
        /// Special form of the contructor used when constructin JsFunctionConstructor
        /// </summary>
        /// <remarks>This constructor is called when the global.FunctionClass isn't set yet.</remarks>
        /// <param name="global">Global</param>
        /// <param name="prototype">Prototype</param>
        protected JsConstructor(IGlobal global, JsObject prototype)
            : base(prototype) {
            Global = global;
        }

        public abstract void InitPrototype(IGlobal global);

        /// <summary>
        /// This method is used to wrap an native value with a js object of the specified type.
        /// </summary>
        /// <remarks>
        /// This method creates a new apropriate js object and stores a CLR value in it.
        /// </remarks>
        /// <typeparam name="T">A type of a native value to wrap</typeparam>
        /// <param name="value">A native value to wrap</param>
        /// <returns>A js instance</returns>
        public virtual IJsInstance Wrap<T>(T value)
        {
            return new JsObject(value,PrototypeProperty);
        }



        #region IFunction Members

        public string Name {
            get { throw new NotImplementedException(); }
        }

        public IList<string> Arguments {
            get { throw new NotImplementedException(); }
        }

        public IJsObject Invoke(IJsObject that, IJsInstance[] parameters) {
            throw new NotImplementedException();
        }

        public IJsObject Construct(IJsInstance[] parameters) {
            throw new NotImplementedException();
        }

        public IJsObject PrototypeProperty {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region IEnumerable Members

        public new System.Collections.IEnumerator GetEnumerator() {
            return GetEnumerator();
        }

        #endregion
    }
}
