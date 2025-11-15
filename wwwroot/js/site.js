// Aplica máscara de CPF
function mascaraCPF(input) {
    let value = input.value.replace(/\D/g, '');
    if (value.length > 11) {
        value = value.substring(0, 11);
    }

    if (value.length > 9) {
        value = value.replace(/^(\d{3})(\d{3})(\d{3})(\d{1,2}).*/, '$1.$2.$3-$4');
    } else if (value.length > 6) {
        value = value.replace(/^(\d{3})(\d{3})(\d{1,3})/, '$1.$2.$3');
    } else if (value.length > 3) {
        value = value.replace(/^(\d{3})(\d{1,3})/, '$1.$2');
    }

    input.value = value;
}

// Inicialização
document.addEventListener('DOMContentLoaded', function() {
    // Aplica máscara de CPF
    const cpfInputs = document.querySelectorAll('input[data-val-cpf]');
    cpfInputs.forEach(input => {
        input.addEventListener('input', function() {
            mascaraCPF(this);
        });
    });

    // Auto-dismiss para mensagens de alerta
    const alertMessages = document.querySelectorAll('.alert');
    alertMessages.forEach(alert => {
        setTimeout(() => {
            alert.style.opacity = '0';
            setTimeout(() => alert.remove(), 500);
        }, 5000);
    });
});