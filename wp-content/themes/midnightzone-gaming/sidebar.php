<?php
/**
 * The sidebar containing the main widget area
 *
 * @link https://developer.wordpress.org/themes/basics/template-files/#template-partials
 *
 * @package MidnightZone_Gaming
 */

if ( ! is_active_sidebar( 'sidebar-1' ) && ! is_active_sidebar('ad-sidebar') ) {
	return;
}
?>

<aside id="secondary" class="widget-area">
    <?php if ( is_active_sidebar( 'ad-sidebar' ) ) : ?>
		<?php dynamic_sidebar( 'ad-sidebar' ); ?>
	<?php endif; ?>
	<?php dynamic_sidebar( 'sidebar-1' ); ?>
</aside><!-- #secondary -->
