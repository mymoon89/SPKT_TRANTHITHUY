<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:import href = "XSL.xsl" />    
  <xsl:template match = "/" >   
     <xsl:apply-templates select = "//BBB" />        
  </xsl:template>         
</xsl:stylesheet>
