<?php
/**
 * Template Name: Clips Page
 *
 * @package MidnightZone_Gaming
 */

get_header(); ?>

<header class="page-header">
    <h1 class="page-title"><?php the_title(); ?></h1>
</header>

<div class="post-grid">
    <?php
    $paged = ( get_query_var( 'paged' ) ) ? get_query_var( 'paged' ) : 1;
    $args = array(
        'post_type'      => 'post',
        'category_name'  => 'clips', // Make sure you have a 'clips' category slug
        'posts_per_page' => get_option('posts_per_page'),
        'paged'          => $paged
    );
    $custom_query = new WP_Query($args);

    if ( $custom_query->have_posts() ) :
        while ( $custom_query->have_posts() ) :
            $custom_query->the_post();
            get_template_part( 'template-parts/content', 'grid' );
        endwhile;
    else :
        get_template_part( 'template-parts/content', 'none' );
    endif;
    ?>
</div>

<?php wp_reset_postdata(); ?>

<div class="load-more-container">
    <button id="load-more-btn" data-query="<?php echo esc_attr( json_encode( $custom_query->query ) ); ?>"><?php esc_html_e( 'Load More', 'midnightzone-gaming' ); ?></button>
</div>

<?php get_footer(); ?>
