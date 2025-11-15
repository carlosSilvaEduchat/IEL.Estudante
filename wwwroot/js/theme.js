// Função para alternar entre temas
function toggleTheme() {
    const html = document.documentElement;
    const currentTheme = html.getAttribute('data-theme');
    const newTheme = currentTheme === 'dark' ? 'light' : 'dark';
    
    // Atualiza o atributo data-theme
    html.setAttribute('data-theme', newTheme);
    
    // Salva a preferência no localStorage
    localStorage.setItem('theme', newTheme);
    
    // Atualiza o ícone do botão
    updateThemeIcon(newTheme);
}

// Função para atualizar o ícone do tema
function updateThemeIcon(theme) {
    const themeIcon = document.querySelector('#theme-toggle i');
    if (themeIcon) {
        if (theme === 'dark') {
            themeIcon.classList.remove('fa-moon');
            themeIcon.classList.add('fa-sun');
        } else {
            themeIcon.classList.remove('fa-sun');
            themeIcon.classList.add('fa-moon');
        }
    }
}

// Função para carregar o tema salvo
function loadTheme() {
    const savedTheme = localStorage.getItem('theme') || 'light';
    const html = document.documentElement;
    
    // Aplica o tema salvo
    html.setAttribute('data-theme', savedTheme);
    
    // Atualiza o ícone do botão
    updateThemeIcon(savedTheme);
}

// Inicialização quando o DOM estiver carregado
document.addEventListener('DOMContentLoaded', function() {
    // Carrega o tema salvo
    loadTheme();
    
    // Adiciona o evento de clique no botão de alternar tema
    const themeToggle = document.getElementById('theme-toggle');
    if (themeToggle) {
        themeToggle.addEventListener('click', toggleTheme);
    }
    
    // Configura o clique no botão do menu
    const sidebarToggle = document.getElementById('sidebar-toggle');
    if (sidebarToggle) {
        sidebarToggle.addEventListener('click', function(e) {
            e.preventDefault();
            toggleMobileMenu();
        });
    }
    
    // Fecha o menu ao clicar em um item
    document.addEventListener('click', function(event) {
        const mobileMenu = document.getElementById('mobileMenu');
        const sidebarToggle = document.getElementById('sidebar-toggle');
        
        if (mobileMenu && 
            !mobileMenu.contains(event.target) && 
            event.target !== sidebarToggle && 
            !sidebarToggle.contains(event.target)) {
            mobileMenu.style.display = 'none';
        }
    });
});

// Função para alternar o menu mobile
function toggleMobileMenu() {
    const mobileMenu = document.getElementById('mobileMenu');
    if (mobileMenu) {
        if (mobileMenu.style.display === 'none' || !mobileMenu.style.display) {
            mobileMenu.style.display = 'block';
        } else {
            mobileMenu.style.display = 'none';
        }
    }
}