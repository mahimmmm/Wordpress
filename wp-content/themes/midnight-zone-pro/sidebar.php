<?php
/**
 * The sidebar containing the main widget area
 *
 * @package Midnight_Zone_Pro
 */

if ( ! is_active_sidebar( 'sidebar-1' ) ) {
	return;
}
?>
<aside id="secondary" class="widget-area sticky-sidebar">
	<?php if ( is_active_sidebar( 'sidebar_large_ad' ) ) : ?>
		<div class="sidebar-ad ad-area">
			<?php dynamic_sidebar( 'sidebar_large_ad' ); ?>
		</div>
	<?php endif; ?>

	<?php dynamic_sidebar( 'sidebar-1' ); ?>

	<?php if ( is_active_sidebar( 'sidebar_medium_ad' ) ) : ?>
		<div class="sidebar-ad ad-area">
			<?php dynamic_sidebar( 'sidebar_medium_ad' ); ?>
		</div>
	<?php endif; ?>
</aside><!-- #secondary -->
