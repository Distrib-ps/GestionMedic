<?php

require "vendor/autoload.php";

use Behat\Mink\Mink,
    Behat\Mink\Session,
    Behat\Mink\Driver\GoutteDriver,
    Goutte\Client as GoutteClient;

$mink = new Mink(array(
    'goutte' => new Session(new GoutteDriver(new GoutteClient())),
));

$session = $mink->getSession('goutte');
$session->visit('https://www.pharmanity.com/medicament/medicaments-p1');
$page = $session->getPage();
$categorieCSV = array();
$medocCSV = array();
$iterator = 1;
$iteratorMedoc = 1;
$medicaments = $page->findAll('css', '#par_nav > li > ul > li');
foreach ($medicaments as $medicament) {
    $categorie = $medicament->find('css', 'a');
    $nomCategorie = trim(explode('(', $categorie->getText())[0]);
    array_push($categorieCSV, array($iterator, $nomCategorie));
    $categorie->click();
    $page2 = $session->getPage();
    $medocs = $page2->findAll('css', 'body > div.container > div > div.col-md-9 > div > div');
    foreach ($medocs as $medoc) {
        $nom = $medoc->find('css', "#thumbnail-label > a")->getText();
        $img = $medoc->find('css', 'div.relative > span > img')->getAttribute('src');
        $prix = $medoc->find('css', 'div.price')->getText();
        $prix = trim(explode(':', $prix)[1]);
        array_push($medocCSV, array($iteratorMedoc, $nom, $img, $prix, $iterator));
        $iteratorMedoc += 1;
    }
    $iterator += 1;
    $page2->find('css', 'body > div.breacrumbWrapper > div > div > div > ol > li:nth-child(3) > a')->click();
}

$fp = fopen('categories.csv', 'w');

foreach ($categorieCSV as $fields) {
    fputcsv($fp, $fields, ";");
}

fclose($fp);

$fp = fopen('medicaments.csv', 'w');

foreach ($medocCSV as $fields) {
    fputcsv($fp, $fields, ";");
}

fclose($fp);
