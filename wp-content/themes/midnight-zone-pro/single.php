<?php
/**
 * The template for displaying all single posts
 *
 * @package Midnight_Zone_Pro
 */

get_header(); ?>

	<div id="primary" class="content-area">
		<main id="main" class="site-main">

		<?php
		while ( have_posts() ) :
			the_post();

			get_template_part( 'template-parts/content', 'single' );

			the_post_navigation();

			// If comments are open or we have at least one comment, load up the comment template.
			if ( comments_open() || get_comments_number() ) :
				comments_template();
			endif;

			// After comments ad
			if ( is_active_sidebar( 'after_comments_ad' ) ) {
				echo '<div class="after-comments-ad ad-area">';
				dynamic_sidebar( 'after_comments_ad' );
				echo '</div>';
			}

			// Related Posts
			$categories = get_the_category( get_the_ID() );
			if ($categories) {
				$category_ids = array();
				foreach($categories as $individual_category) $category_ids[] = $individual_category->term_id;
				$args = array(
					'category__in'     => $category_ids,
					'post__not_in'     => array( get_the_ID() ),
					'posts_per_page'   => 3,
					'ignore_sticky_posts' => 1
				);
				$related_posts = new wp_query( $args );
				if( $related_posts->have_posts() ) {
					echo '<div class="related-posts">';
					echo '<h3>' . esc_html__( 'Related Posts', 'midnight-zone-pro' ) . '</h3>';
					echo '<div class="related-posts-grid">';
					while( $related_posts->have_posts() ) {
						$related_posts->the_post();
						get_template_part( 'template-parts/content', 'related' );
					}
					echo '</div>';
					echo '</div>';
				}
				wp_reset_postdata();
			}

		endwhile; // End of the loop.
		?>

		</main><!-- #main -->
	</div><!-- #primary -->

<?php
get_sidebar();
get_footer();
