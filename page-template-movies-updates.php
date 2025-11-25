<?php
/**
 * Template Name: Movies Updates
 *
 * @package MidnightZone
 */

get_header(); ?>

<div id="primary" class="content-area">
    <main id="main" class="site-main">

        <header class="page-header">
            <?php the_title( '<h1 class="page-title">', '</h1>' ); ?>
        </header><!-- .page-header -->

        <?php
        $args = array(
            'post_type' => 'post',
            'category_name' => 'movies-updates', // Make sure you have a category with this slug
            'posts_per_page' => 10,
            'paged' => get_query_var( 'paged' ) ? get_query_var( 'paged' ) : 1,
        );
        $category_posts = new WP_Query( $args );

        if ( $category_posts->have_posts() ) :
            while ( $category_posts->have_posts() ) : $category_posts->the_post();
                get_template_part( 'template-parts/content', get_post_format() );
            endwhile;

            // Pagination
            $big = 999999999; // need an unlikely integer
            echo paginate_links( array(
                'base' => str_replace( $big, '%#%', esc_url( get_pagenum_link( $big ) ) ),
                'format' => '?paged=%#%',
                'current' => max( 1, get_query_var('paged') ),
                'total' => $category_posts->max_num_pages
            ) );

            wp_reset_postdata();
        else :
            get_template_part( 'template-parts/content', 'none' );
        endif;
        ?>

    </main><!-- #main -->
</div><!-- #primary -->

<?php
get_sidebar();
get_footer();
