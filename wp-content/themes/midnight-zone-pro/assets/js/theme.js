document.addEventListener('DOMContentLoaded', function () {
    // Mode Toggle
    const modeToggle = document.querySelector('.mode-toggle');
    if (modeToggle) {
        modeToggle.addEventListener('click', function () {
            document.body.classList.toggle('light-mode');
            if (document.body.classList.contains('light-mode')) {
                localStorage.setItem('themeMode', 'light-mode');
            } else {
                localStorage.removeItem('themeMode');
            }
        });
    }

    // Load saved mode
    const currentMode = localStorage.getItem('themeMode');
    if (currentMode) {
        document.body.classList.add(currentMode);
    }

    // Search Toggle
    const searchIcon = document.querySelector('.search-icon');
    const searchContainer = document.querySelector('.search-form-container');
    if (searchIcon && searchContainer) {
        searchIcon.addEventListener('click', function (event) {
            event.stopPropagation();
            searchContainer.classList.toggle('active');
        });

        // Hide search on click outside
        document.addEventListener('click', function (event) {
            if (!searchContainer.contains(event.target)) {
                searchContainer.classList.remove('active');
            }
        });
    }

    // Mobile Menu Toggle
    const menuToggle = document.querySelector('.mobile-menu-toggle');
    const mobileMenu = document.getElementById('mobile-menu-container');
    if (menuToggle && mobileMenu) {
        menuToggle.addEventListener('click', function () {
            mobileMenu.classList.toggle('active');
        });
    }
});
