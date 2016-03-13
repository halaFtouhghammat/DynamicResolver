using DynamicResolver.Interfaces;
using System;

namespace DynamicResolver.Dll1
{
    /// <summary>
    /// Sample class which use WPF's PresentationFramework.dll to show message box
    /// </summary>
    [Serializable]
    public class Class1 : MarshalByRefObject, ITest
    {
        public int MyProperty { get; set; }

        public IExample Test()
        {
            System.Windows.MessageBox.Show(string.Format("Test ;)"));
            return new Example() { MyInt = 6, MyString = @"Hello" };
        }

        [Serializable]
        public class Example : MarshalByRefObject, IExample
        {
            public int MyInt { get; set; }
            public string MyString { get; set; }
        }
    }
}