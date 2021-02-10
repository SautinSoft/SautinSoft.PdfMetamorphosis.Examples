<?php

$p = new COM("SautinSoft.PdfMetamorphosis");

/* Convert RTF file to PDF file */
$result = $p->RtfToPdfConvertFile("d:\\Source.rtf", "d:\\Result.pdf");

print($result);

?>