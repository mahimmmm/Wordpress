document.addEventListener('DOMContentLoaded', function () {
    const modeToggle = document.querySelector('.mode-toggle');
    const body = document.body;

    // Check for saved user preference, if any, on load
    const currentMode = localStorage.getItem('themeMode');
    if (currentMode) {
        body.classList.add(currentMode);
    }

    modeToggle.addEventListener('click', function () {
        body.classList.toggle('light-mode');

        // Save the user's preference
        if (body.classList.contains('light-mode')) {
            localStorage.setItem('themeMode', 'light-mode');
        } else {
            localStorage.removeItem('themeMode');
        }
    });
});
