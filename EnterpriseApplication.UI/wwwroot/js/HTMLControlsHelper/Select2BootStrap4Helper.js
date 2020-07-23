class Select2BootStrap4Helper
{
    static Initialize()
    {
        //Initialize Select2 Elements
        $('.select2bs4').select2({
            theme: 'bootstrap4'
        });
    }

    static InitializeById(id) {
        //Initialize Select2 Elements
        $('#' + id + '.select2bs4').select2({
            theme: 'bootstrap4'
        });
    }
    static LoadData(id,data, idName, valueName)
    {
        let element = $('#' + id);
        var defaultOption = new Option('Select', 0, true, false);
        element.append(defaultOption);

        for (let index in data) {
            var comboId = data[index][idName];
            var value = data[index][valueName];
            var newOption = new Option(value, comboId, false, false);
            element.append(newOption);
        }     
        element.trigger('change');
    }

    static AddSelectEvent(id, callback)
    {
        let element = $('#' + id);
        element.on('select2:select', function (e) {
            var selectedId = e.params.data.id;
            if (typeof callback !== 'undefined')
               callback(selectedId);
        });
    }
}