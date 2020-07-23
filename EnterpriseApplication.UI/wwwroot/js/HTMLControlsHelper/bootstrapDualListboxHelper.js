class bootstrapDualListboxHelper
{

    static Initialize(nonSelectedListTitle, selectedListTitle)
    {
        $('.duallistbox').bootstrapDualListbox(
            {
                nonSelectedListLabel: nonSelectedListTitle,
                selectedListLabel: selectedListTitle,
                preserveSelectionOnMove: 'moved',
                moveOnSelect: false
            });
    }

    static InitializeById(id, nonSelectedListTitle, selectedListTitle)
    {
        $('#' + id + '.duallistbox').bootstrapDualListbox(
        {
            nonSelectedListLabel: nonSelectedListTitle,
            selectedListLabel: selectedListTitle,
            preserveSelectionOnMove: 'moved',
            moveOnSelect: false
        });
    }

    static LoadData(id, data, idName, valueName,selected)
    {
        let element = $('#' + id);
        
        for (let index in data) {
            var comboId = data[index][idName];
            var value = data[index][valueName];
            var newOption = new Option(value, comboId, false, selected);
            element.append(newOption);
        }
        element.bootstrapDualListbox('refresh', true);
       // element.trigger('change');
    }
    static clear(id)
    {
        let element = $('#' + id);     
        element.empty();
    }


}