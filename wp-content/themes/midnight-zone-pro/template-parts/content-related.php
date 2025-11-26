<?php
/**
 * Template part for displaying related posts
 *
 * @package Midnight_Zone_Pro
 */
?>
<article id="post-<?php the_ID(); ?>" <?php post_class('related-post-card'); ?>>
    <?php if ( has_post_thumbnail() ) : ?>
        <div class="related-post-thumbnail">
            <a href="<?php the_permalink(); ?>">
                <?php the_post_thumbnail( 'medium' ); ?>
            </a>
        </div>
    <?php endif; ?>
    <header class="entry-header">
        <?php the_title( sprintf( '<h4 class="entry-title"><a href="%s" rel="bookmark">', esc_url( get_permalink() ) ), '</a></h4>' ); ?>
    </header>
</article>
