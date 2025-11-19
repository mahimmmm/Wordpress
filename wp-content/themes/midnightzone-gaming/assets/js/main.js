(function($) {
    'use strict';

    $(document).ready(function() {

        // --- Mobile Menu Toggle ---
        $('.menu-toggle').on('click', function() {
            $('.main-navigation').toggleClass('toggled');
        });

        // --- Dark Mode Toggle ---
        // --- Dark Mode Toggle ---
        const darkModeToggle = $('#dark-mode-toggle');
        if (darkModeToggle.length) {
            // Check for saved preference on page load
            if (localStorage.getItem('theme') === 'light') {
                $('body').addClass('light-mode');
            }

            darkModeToggle.on('click', function() {
                $('body').toggleClass('light-mode');
                if ($('body').hasClass('light-mode')) {
                    localStorage.setItem('theme', 'light');
                } else {
                    localStorage.removeItem('theme');
                }
            });
        }

        // --- AJAX Load More ---
        let currentPage = 1;
        $('#load-more-btn').on('click', function(e) {
            e.preventDefault();
            const button = $(this);
            const query_vars = button.data('query');
            button.text('Loading...');

            $.ajax({
                url: mzg_ajax.ajax_url,
                type: 'post',
                data: {
                    action: 'load_more_posts',
                    page: currentPage,
                    nonce: mzg_ajax.nonce,
                    query_vars: JSON.stringify(query_vars)
                },
                success: function(response) {
                    if (response.trim() !== '') {
                        $('.post-grid').append(response);
                        currentPage++;
                        button.text('Load More');
                    } else {
                        button.text('No More Posts').prop('disabled', true);
                    }
                },
                error: function() {
                    button.text('Error').prop('disabled', true);
                }
            });
        });

    });

})(jQuery);
