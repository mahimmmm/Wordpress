<?php
/**
 * The template for displaying the footer
 *
 * @package Midnight_Zone_Pro
 */
?>
	</div><!-- #content -->
	<?php if ( is_active_sidebar( 'before_footer_ad' ) ) : ?>
		<div class="before-footer-ad-area ad-area">
			<?php dynamic_sidebar( 'before_footer_ad' ); ?>
		</div>
	<?php endif; ?>

	<footer id="colophon" class="site-footer">
		<div class="footer-container">
			<div class="footer-column">
				<?php dynamic_sidebar( 'footer-1' ); ?>
			</div>
			<div class="footer-column">
				<?php dynamic_sidebar( 'footer-2' ); ?>
			</div>
			<div class="footer-column">
				<?php dynamic_sidebar( 'footer-3' ); ?>
			</div>
			<div class="footer-column">
				<?php dynamic_sidebar( 'footer-4' ); ?>
			</div>
		</div>
		<div class="site-info">
			&copy; <?php echo date('Y'); ?> <?php bloginfo('name'); ?>. All Rights Reserved.
		</div>
	</footer><!-- #colophon -->
</div><!-- #page -->
<?php wp_footer(); ?>
</body>
</html>
