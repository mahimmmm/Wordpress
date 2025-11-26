<?php
/**
 * Template part for displaying a message that posts cannot be found
 *
 * @package Midnight_Zone_Pro
 */
?>
<section class="no-results not-found">
	<header class="page-header">
		<h1 class="page-title"><?php esc_html_e( 'Nothing Found', 'midnight-zone-pro' ); ?></h1>
	</header>
	<div class="page-content">
		<p><?php esc_html_e( 'It seems we can&rsquo;t find what you&rsquo;re looking for. Perhaps searching can help.', 'midnight-zone-pro' ); ?></p>
		<?php get_search_form(); ?>
	</div>
</section>
