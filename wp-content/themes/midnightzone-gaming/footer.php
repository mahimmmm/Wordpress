            </main><!-- #main -->
        </div><!-- #primary -->

        <?php get_sidebar(); ?>

    </div><!-- #content -->

    <?php if ( is_active_sidebar( 'ad-footer' ) ) : ?>
        <div class="footer-ad-area">
            <?php dynamic_sidebar( 'ad-footer' ); ?>
        </div>
    <?php endif; ?>

	<footer id="colophon" class="site-footer">
		<div class="container">
            <div class="footer-widgets">
                <div class="footer-column">
                    <?php if ( is_active_sidebar( 'footer-1' ) ) : ?>
                        <?php dynamic_sidebar( 'footer-1' ); ?>
                    <?php endif; ?>
                </div>
                <div class="footer-column">
                    <?php if ( is_active_sidebar( 'footer-2' ) ) : ?>
                        <?php dynamic_sidebar( 'footer-2' ); ?>
                    <?php endif; ?>
                </div>
                <div class="footer-column">
                    <?php if ( is_active_sidebar( 'footer-3' ) ) : ?>
                        <?php dynamic_sidebar( 'footer-3' ); ?>
                    <?php endif; ?>
                </div>
            </div>

			<div class="copyright">
				&copy; <?php echo date( 'Y' ); ?> <?php bloginfo( 'name' ); ?>. All Rights Reserved.
			</div><!-- .copyright -->
		</div><!-- .container -->
	</footer><!-- #colophon -->
</div><!-- #page -->

<?php wp_footer(); ?>

</body>
</html>
