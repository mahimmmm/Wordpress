<article id="post-<?php the_ID(); ?>" <?php post_class(); ?>>
	<div class="post-thumbnail">
		<a href="<?php the_permalink(); ?>">
			<?php the_post_thumbnail('medium_large'); ?>
		</a>
	</div>

	<header class="entry-header">
		<?php the_title( '<h2 class="entry-title"><a href="' . esc_url( get_permalink() ) . '" rel="bookmark">', '</a></h2>' ); ?>
	</header><!-- .entry-header -->

	<div class="entry-summary">
		<?php the_excerpt(); ?>
	</div><!-- .entry-summary -->
</article><!-- #post-<?php the_ID(); ?> -->
