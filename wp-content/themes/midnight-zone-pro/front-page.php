<?php
/**
 * The template for displaying the front page
 *
 * @package Midnight_Zone_Pro
 */

get_header(); ?>

	<div id="primary" class="content-area">
		<main id="main" class="site-main">
			<?php if ( is_active_sidebar( 'header_ad' ) ) : ?>
				<div class="header-ad-area ad-area">
					<?php dynamic_sidebar( 'header_ad' ); ?>
				</div>
			<?php endif; ?>

			<section class="hero-section">
				<div id="particles-js"></div>
				<div class="hero-content">
					<div class="hero-card-grid">
						<?php
						$hero_cards = [
							'serials'           => 'Serials',
							'dress-cosmetics'   => 'Dress & Cosmetics',
							'movies'            => 'Movies',
						];
						foreach ( $hero_cards as $slug => $title ) :
							$category_link = get_category_link( get_cat_ID( $title ) );
						?>
						<div class="hero-card tilt-effect">
							<div class="card-content">
								<h3><?php echo esc_html( $title ); ?></h3>
								<p>Explore the latest in <?php echo esc_html( strtolower( $title ) ); ?>.</p>
								<a href="<?php echo esc_url( $category_link ); ?>" class="btn-explore">Explore</a>
							</div>
						</div>
						<?php endforeach; ?>
					</div>
				</div>
			</section>

			<?php if ( is_active_sidebar( 'after_hero_ad' ) ) : ?>
				<div class="after-hero-ad-area ad-area">
					<?php dynamic_sidebar( 'after_hero_ad' ); ?>
				</div>
			<?php endif; ?>

			<div class="main-content-area">
				<div class="main-column">
					<section class="recent-posts">
						<h2 class="section-title">Recent Posts</h2>
						<?php
						$recent_posts = new WP_Query( array( 'posts_per_page' => 8 ) );
						if ( $recent_posts->have_posts() ) :
							while ( $recent_posts->have_posts() ) : $recent_posts->the_post();
								get_template_part( 'template-parts/content', 'row' );
							endwhile;
							wp_reset_postdata();
						endif;
						?>
					</section>

					<section class="popular-posts">
						<h2 class="section-title">Popular Posts</h2>
						<?php
						$popular_posts = new WP_Query( array( 'posts_per_page' => 8, 'orderby' => 'comment_count' ) );
						if ( $popular_posts->have_posts() ) :
							while ( $popular_posts->have_posts() ) : $popular_posts->the_post();
								get_template_part( 'template-parts/content', 'row' );
							endwhile;
							wp_reset_postdata();
						endif;
						?>
					</section>
				</div>
				<div class="sidebar-column">
					<?php get_sidebar(); ?>
				</div>
			</div>

		</main><!-- #main -->
	</div><!-- #primary -->

<?php
get_footer();
