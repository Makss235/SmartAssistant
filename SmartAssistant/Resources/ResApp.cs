using System.Windows;

namespace SmartAssistant.Resources
{
    internal static class ResApp
    {
        internal static T GetResources<T>(string nameResources) where T : class
        {
            return Application.Current.Resources[nameResources] as T;
        }
    }
}
