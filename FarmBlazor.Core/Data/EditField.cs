// Ignore Spelling: Blazor

namespace FarmBlazor.Core
{
    public class EditField
    {
        public string? FieldName { get; init; }

        public Guid GUID { get; init; }

        public object? Value { get; init; }

        public object? EditedValue { get; set; }

        public object? Model { get; init; }

        public bool IsDirty
        {
            get
            {
                if (Value != null && EditedValue != null) return !Value.Equals(EditedValue);
                if (Value is null && EditedValue is null) return false;
                return true;
            }
        }

        public EditField(object model, string fieldName, object value)
            => (this.Model, this.FieldName, this.Value, this.EditedValue, this.GUID) = (model, fieldName, value, value, Guid.NewGuid());

        public void Reset() => this.EditedValue = this.Value;
    }
}
