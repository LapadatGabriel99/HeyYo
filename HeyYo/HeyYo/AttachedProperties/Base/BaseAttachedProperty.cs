using System;
using Xamarin.Forms;

namespace HeyYo.AttachedProperties.Base
{
    public abstract class BaseAttachedProperty<Parent, Property> where Parent : new()
    {        
        public static Parent Instance { get; private set; } = new Parent();

        public static readonly BindableProperty ValueProperty =
            BindableProperty.CreateAttached(
                "Value",
                typeof(Property),
                typeof(BaseAttachedProperty<Parent, Property>),
                default(Property),
                propertyChanged: OnValuePropertyChanged,
                coerceValue: OnValuePropertyUpdated);

        public static Property GetValue(BindableObject bindable) => (Property)bindable.GetValue(ValueProperty);

        public static void SetValue(BindableObject bindable, Property value) => bindable.SetValue(ValueProperty, value);

        public static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueChanged(bindable, oldValue, newValue);
        }

        public static object OnValuePropertyUpdated(BindableObject bindable, object value)
        {
            (Instance as BaseAttachedProperty<Parent, Property>)?.OnValueUpdated(bindable, value);

            return value;
        }

        public virtual void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        public virtual void OnValueUpdated(BindableObject bindable, object value)
        {

        }
    }
}
