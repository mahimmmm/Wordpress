<?php get_header(); ?>

<div class="hero-grid">
    <?php
    $hero_query = new WP_Query( array(
        'posts_per_page'      => 4,
        'meta_key'            => 'mzg_post_views_count',
        'orderby'             => 'meta_value_num',
        'order'               => 'DESC',
        'ignore_sticky_posts' => 1
    ) );

    if ( $hero_query->have_posts() ) :
        while ( $hero_query->have_posts() ) : $hero_query->the_post(); ?>
            <a href="<?php the_permalink(); ?>" class="hero-post">
                <?php if ( has_post_thumbnail() ) : ?>
                    <?php the_post_thumbnail( 'large' ); ?>
                <?php endif; ?>
                <div class="hero-post-content">
                    <h2><?php the_title(); ?></h2>
                    <span class="post-meta">
                        <?php echo mzg_get_post_views(get_the_ID()); ?>
                    </span>
                </div>
            </a>
        <?php endwhile;
        wp_reset_postdata();
    else:
        // Fallback content if no posts are found
        echo '<p>No featured posts available.</p>';
    endif;
    ?>
</div>

<?php if ( is_active_sidebar( 'ad-below-hero' ) ) { dynamic_sidebar( 'ad-below-hero' ); } ?>

<div class="post-grid">
    <?php
    $main_query = new WP_Query( array( 'posts_per_page' => get_option( 'posts_per_page' ), 'paged' => 1 ) );
    if ( $main_query->have_posts() ) :
        while ( $main_query->have_posts() ) :
            $main_query->the_post();
            get_template_part( 'template-parts/content', 'grid' );
        endwhile;
    else :
        get_template_part( 'template-parts/content', 'none' );
    endif;
    ?>
</div>

<div class="load-more-container">
    <button id="load-more-btn" data-query="<?php echo esc_attr( json_encode( $main_query->query ) ); ?>"><?php esc_html_e( 'Load More', 'midnightzone-gaming' ); ?></button>
</div>

<?php get_footer(); ?>
