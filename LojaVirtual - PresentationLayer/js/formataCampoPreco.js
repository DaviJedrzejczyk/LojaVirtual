$(document).ready(function () {
    $('#' + txtPreco).on('input', function () {
        var valorAtual = $(this).val();

        var valorLimpo = valorAtual.replace(/\D/g, '');

        if (valorLimpo.length > 0) {
            var valorFormatado = formatarParaBRL(valorLimpo);
            $(this).val(valorFormatado);  
        } else {
            $(this).val(''); 
        }
    });

    function formatarParaBRL(valor) {
        var valorFormatado = (parseFloat(valor) / 100).toFixed(2);

        // Formata o valor em BRL usando Intl.NumberFormat
        return new Intl.NumberFormat('pt-BR', {
            style: 'currency',
            currency: 'BRL'
        }).format(valorFormatado);
    }
});