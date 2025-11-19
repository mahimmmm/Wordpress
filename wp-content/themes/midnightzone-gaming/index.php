<?php get_header(); ?>

<?php midnightzone_gaming_breadcrumbs(); ?>

<div class="post-grid">
    <?php
    if ( have_posts() ) :
        while ( have_posts() ) :
            the_post();
            get_template_part( 'template-parts/content', 'grid' );
        endwhile;
    else :
        get_template_part( 'template-parts/content', 'none' );
    endif;
    ?>
</div>

<div class="load-more-container">
    <button id="load-more-btn" data-query="<?php echo esc_attr( json_encode( $wp_query->query ) ); ?>"><?php esc_html_e( 'Load More', 'midnightzone-gaming' ); ?></button>
</div>

<?php get_footer(); ?>
