<xsl:stylesheet version="1.0"
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html"/>

<xsl:template match="PERSON">
   <html>
      <body>     	 
		 <img src="{unparsed-entity-uri(@PHOTO)}"/>	
      </body>
   </html>
</xsl:template>

</xsl:stylesheet> 