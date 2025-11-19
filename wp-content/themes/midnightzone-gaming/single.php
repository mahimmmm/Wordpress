<?php get_header(); ?>

<?php
while ( have_posts() ) :
    the_post();
    mzg_set_post_views(get_the_ID());
?>

<article id="post-<?php the_ID(); ?>" <?php post_class('single-post'); ?>>

    <?php midnightzone_gaming_breadcrumbs(); ?>

	<header class="entry-header">
		<?php the_title( '<h1 class="entry-title">', '</h1>' ); ?>
        <div class="entry-meta">
			<?php the_date(); ?> by <?php the_author(); ?>
		</div><!-- .entry-meta -->
	</header><!-- .entry-header -->

    <?php if ( has_post_thumbnail() ) : ?>
        <div class="post-thumbnail">
            <?php the_post_thumbnail( 'full' ); ?>
        </div>
    <?php endif; ?>

	<div class="entry-content">
		<?php
		the_content();
		wp_link_pages(
			array(
				'before' => '<div class="page-links">' . esc_html__( 'Pages:', 'midnightzone-gaming' ),
				'after'  => '</div>',
			)
		);
		?>
	</div><!-- .entry-content -->

	<footer class="entry-footer">
		<?php the_tags('Tags: ', ', '); ?>
	</footer><!-- .entry-footer -->
</article><!-- #post-<?php the_ID(); ?> -->

<?php
    // If comments are open or we have at least one comment, load up the comment template.
    if ( comments_open() || get_comments_number() ) :
        comments_template();
    endif;

    // Display related posts
    midnightzone_gaming_related_posts();

endwhile; // End of the loop.
?>

<?php get_footer(); ?>
