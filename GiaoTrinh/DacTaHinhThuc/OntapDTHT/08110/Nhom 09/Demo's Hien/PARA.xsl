<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match = "/" >  
          <xsl:call-template name = "print" > 
                <xsl:with-param name = "A" >11  
                 </xsl:with-param>  
                <xsl:with-param name = "B" >33 
                </xsl:with-param> 
       </xsl:call-template> 
         <xsl:call-template name = "print" > 
                <xsl:with-param name = "A" >55 
                </xsl:with-param> 
          </xsl:call-template> 
    </xsl:template> 
     <xsl:template name = "print" >  
               <xsl:param name = "A" />  
               <xsl:param name = "B" >111</xsl:param>  
               <xsl:text ></xsl:text>  
               <xsl:value-of select = "$A" />  
               <xsl:text > + </xsl:text>  
               <xsl:value-of select = "$B" />  
               <xsl:text > = </xsl:text>  
               <xsl:value-of select = "$A+$B" />  
     </xsl:template> 
</xsl:stylesheet>
