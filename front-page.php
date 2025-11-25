<?php get_header(); ?>

<div id="primary" class="content-area">
    <main id="main" class="site-main">

        <!-- Top Banner Ad -->
        <?php if ( is_active_sidebar( 'header-ad' ) ) : ?>
            <div class="top-banner-ad">
                <?php dynamic_sidebar( 'header-ad' ); ?>
            </div>
        <?php endif; ?>

        <!-- Hero Section -->
        <section class="hero-section">
            <h2>Popular Content</h2>
            <div class="hero-posts">
                <?php
                $popular_posts_query = new WP_Query( array( 'posts_per_page' => 4, 'orderby' => 'comment_count', 'ignore_sticky_posts' => 1 ) );
                if ( $popular_posts_query->have_posts() ) :
                    while ( $popular_posts_query->have_posts() ) : $popular_posts_query->the_post();
                        ?>
                        <div class="hero-post-card">
                            <?php if ( has_post_thumbnail() ) : ?>
                                <div class="hero-post-thumbnail">
                                    <a href="<?php the_permalink(); ?>">
                                        <?php the_post_thumbnail( 'medium' ); ?>
                                    </a>
                                </div>
                            <?php endif; ?>
                            <h3 class="hero-post-title"><a href="<?php the_permalink(); ?>"><?php the_title(); ?></a></h3>
                        </div>
                        <?php
                    endwhile;
                    wp_reset_postdata();
                else :
                    echo '<p>No popular posts found.</p>';
                endif;
                ?>
            </div>
        </section>

        <!-- After Hero Banner Ad -->
        <?php if ( is_active_sidebar( 'after-hero-ad' ) ) : ?>
            <div class="after-hero-banner-ad">
                <?php dynamic_sidebar( 'after-hero-ad' ); ?>
            </div>
        <?php endif; ?>

        <!-- Main Content -->
        <section class="main-content">
        <?php
		if ( have_posts() ) :

			/* Start the Loop */
			while ( have_posts() ) :
				the_post();
				get_template_part( 'template-parts/content', get_post_format() );
			endwhile;

			the_posts_navigation();

		else :

			get_template_part( 'template-parts/content', 'none' );

		endif;
		?>
        </section>

    </main><!-- #main -->
</div><!-- #primary -->

<?php
get_sidebar();
get_footer();
