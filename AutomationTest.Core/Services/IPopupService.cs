using System;
using System.Threading.Tasks;

namespace AutomationTest.Core.Services
{
    public interface IPopupService
    {
        void ShowToast(string message);

        Task<DateTimeOffset> ShowDatePicker(DateTimeOffset date);
    }
}
