<?php
/**
 * The template for displaying search results pages
 *
 * @link https://developer.wordpress.org/themes/basics/template-hierarchy/#search-result
 *
 * @package MidnightZone_Gaming
 */

get_header();
?>

	<header class="page-header">
		<h1 class="page-title">
			<?php
			/* translators: %s: search query. */
			printf( esc_html__( 'Search Results for: %s', 'midnightzone-gaming' ), '<span>' . get_search_query() . '</span>' );
			?>
		</h1>
	</header><!-- .page-header -->

	<div class="post-grid">
		<?php
		if ( have_posts() ) :
			/* Start the Loop */
			while ( have_posts() ) :
				the_post();
				get_template_part( 'template-parts/content', 'grid' );
			endwhile;
		else :
			get_template_part( 'template-parts/content', 'none' );
		endif;
		?>
	</div>

	<?php the_posts_pagination(); ?>

<?php
get_footer();
