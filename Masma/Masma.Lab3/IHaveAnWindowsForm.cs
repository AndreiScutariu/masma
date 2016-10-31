using Masma.Lab3.Form;

namespace Masma.Lab3
{
    public interface IHaveAnWindowsForm
    {
        FormAgent Form { get; set; }
    }

    public interface IContainNumberProviders
    {
        int NumberOfProviders { get; set; }
    }
}