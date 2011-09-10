<xsl:stylesheet version="1.0"
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html"/>

<xsl:template match="IMAGE">
   <html>
      <body>     	 
		 <img src="{unparsed-entity-uri(@SOURCE)}"/>	
      </body>
   </html>
</xsl:template>

</xsl:stylesheet> 