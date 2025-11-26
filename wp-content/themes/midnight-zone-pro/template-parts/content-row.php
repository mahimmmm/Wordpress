<?php
/**
 * Template part for displaying posts in a row format
 *
 * @package Midnight_Zone_Pro
 */
?>
<article id="post-<?php the_ID(); ?>" <?php post_class('post-row'); ?>>
    <div class="post-thumbnail">
        <a href="<?php the_permalink(); ?>">
            <?php if ( has_post_thumbnail() ) : ?>
                <?php the_post_thumbnail( array( 250, 250 ) ); ?>
            <?php else : ?>
                <div class="placeholder-image"></div>
            <?php endif; ?>
        </a>
    </div>
    <div class="post-content">
        <header class="entry-header">
            <?php the_title( sprintf( '<h3 class="entry-title"><a href="%s" rel="bookmark">', esc_url( get_permalink() ) ), '</a></h3>' ); ?>
        </header>
        <div class="entry-summary">
            <?php echo wp_trim_words( get_the_excerpt(), 20, '...' ); ?>
            <a href="<?php the_permalink(); ?>" class="read-more">Read More</a>
        </div>
    </div>
</article>
