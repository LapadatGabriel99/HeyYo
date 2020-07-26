using HeyYo.AttachedProperties.Base;
using HeyYo.Core.App.Text.Client;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeyYo.AttachedProperties
{
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        public override void OnValueUpdated(BindableObject bindable, object value)
        {
            if (!(bindable is VisualElement element))
            {
                return;
            }

            DoAnimation(element, (bool)value);
        }

        public abstract void DoAnimation(VisualElement element, bool value);
    }

    public class AnimateTitleProperty : AnimateBaseProperty<AnimateTitleProperty>
    {
        public override async void DoAnimation(VisualElement element, bool value)
        {
            if (value)
            {
                await element.FadeTo(0, 1000, Easing.SpringOut);

                await Task.Factory.StartNew(() =>
                      Device.BeginInvokeOnMainThread(() => (element as Label).Text = TextNormalization.MainPageAlternativeTitle));

                await element.FadeTo(1, 1000, Easing.SpringIn);
            }
        }
    }
}
