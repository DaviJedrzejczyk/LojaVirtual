$(document).ready(function () {
    var originalValue = '';
    
    $('#' + txtData).mask('00/00/0000');

    $('#' + txtData).on('focus', function () {
        originalValue = $(this).val();
    });

    $('#' + txtData).on('blur', function () {
        var currentValue = $(this).val();
        if (currentValue !== originalValue) {
            if (!isValidDate(currentValue)) {
                alert('Data inv\u00E1lida! Por favor, insira uma data real no formato dd/mm/aaaa.');
                $(this).val('');
            }
        }
    });
    function isValidDate(dateString) {
        var regEx = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/;
        if (!dateString.match(regEx)) return false;

        var parts = dateString.split('/');
        var day = parseInt(parts[0], 10);
        var month = parseInt(parts[1], 10) - 1;
        var year = parseInt(parts[2], 10);

        var date = new Date(year, month, day);

        if (date.getFullYear() !== year || date.getMonth() !== month || date.getDate() !== day) {
            return false;
        }
        return true;
    }
});