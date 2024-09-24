function validateInput(event) {
    const input = event.target;
    const value = input.value;

    // Permitir apenas n�meros e controlar o valor
    if (/[^0-9]/.test(value)) {
        input.value = value.replace(/[^0-9]/g, '');
    }
}