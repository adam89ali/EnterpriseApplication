class SelectHelper
{
    static BindData(Id, data,idName,valueName)
    {
        let element = $('#' + Id);
        element.append('<option value="" selected="selected">-Select-</option>');
        for (let index in data)
        {
            var id = data[index][idName];
            var value = data[index][valueName];
            element.append("<option value=\"" + id + "\">" + value + "</option>");
        }
    }
    static AddOnChangeEvent(Id, callback)
    {
        let element = $('#' + Id);
        element.on('change', function () {
           // alert(this.value);
            if (typeof callback !== 'undefined')
            callback(this.value);
        });

    }
}