<?php
/**
 * Template part for displaying posts
 *
 * @package Midnight_Zone_Pro
 */
?>
<article id="post-<?php the_ID(); ?>" <?php post_class(); ?>>
	<header class="entry-header">
		<?php
		the_title( sprintf( '<h2 class="entry-title"><a href="%s" rel="bookmark">', esc_url( get_permalink() ) ), '</a></h2>' );
		?>
	</header>
	<div class="entry-summary">
		<?php the_excerpt(); ?>
	</div>
</article>
